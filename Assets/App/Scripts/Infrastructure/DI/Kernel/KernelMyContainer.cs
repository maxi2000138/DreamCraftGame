using System.Collections.Generic;
using MyContainer.Container;
using Scopes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KernelMyContainer
{
    private const string BootstrapScopePath = "Infrastructure/BootstrapScope";
    private const string BootstrapScopeName = "BootstrapScope";
    
    public static KernelMyContainer Instance
    {
        get
        {
            if (_instance == null) 
                _instance = new KernelMyContainer();

            return _instance;
        }
    }
    
    private static KernelMyContainer _instance;

    private bool _projectScopeInitialized;

    private readonly ProjectScopeRegistry _projectScopeRegistry = new();
    private readonly SceneScopeRegistry _sceneScopeRegistry = new();

    public void TryInitProjectScope()
    {
        if (_projectScopeInitialized)
            return;
            
        LifetimeScopeProject scopeProject = SpawnProjectScope();
        scopeProject.TryInitialize();
        
        _projectScopeInitialized = true;
    }
    
    private LifetimeScopeProject SpawnProjectScope()
    {
        LifetimeScopeProject scopeProjectPrefab = Resources.Load<LifetimeScopeProject>(BootstrapScopePath);
        LifetimeScopeProject scopeProject = Object.Instantiate(scopeProjectPrefab);
        scopeProject.name = BootstrapScopeName;
        return scopeProject;
    }
    
    public void SetupNewScope(LifetimeScope scope)
    {
        VisitorSetupNewScope visitor = new VisitorSetupNewScope(_projectScopeRegistry, _sceneScopeRegistry);
        visitor.Visit(scope);  
    }
    
    public IEnumerable<RegistrationData> GetRegistrationsData(LifetimeScope scope)
    {
        VisitorGetRegistrationsData visitor = new VisitorGetRegistrationsData(_projectScopeRegistry, _sceneScopeRegistry);
        visitor.Visit(scope);
        return visitor.RegistrationsData;
    }
    
    private class VisitorSetupNewScope : VisitorLifetimeScopeBase
    {
        private readonly ProjectScopeRegistry _projectScopeRegistry;
        private readonly SceneScopeRegistry _sceneScopeRegistry;


        public VisitorSetupNewScope(ProjectScopeRegistry projectScopeRegistry, SceneScopeRegistry sceneScopeRegistry)
        {
            _projectScopeRegistry = projectScopeRegistry;
            _sceneScopeRegistry = sceneScopeRegistry;
        }
        public override void Visit(LifetimeScopeProject visitor)
        {
            _projectScopeRegistry.Add(visitor);
        }
        public override void Visit(LifetimeScopeScene visitor)
        {
            _sceneScopeRegistry.Add(visitor);
        }
    }

    private class VisitorGetRegistrationsData : VisitorLifetimeScopeBase
    {
        public IEnumerable<RegistrationData> RegistrationsData { get; private set; }

        private readonly SceneScopeRegistry _sceneScopeRegistry;
        private readonly ProjectScopeRegistry _projectScopeRegistry;

        public VisitorGetRegistrationsData(ProjectScopeRegistry projectScopeRegistry, SceneScopeRegistry sceneScopeRegistry)
        {
            _projectScopeRegistry = projectScopeRegistry;
            _sceneScopeRegistry = sceneScopeRegistry;
        }
        public override void Visit(LifetimeScopeProject visitor)
        {
            RegistrationsData = new List<RegistrationData>
            {
                new RegistrationData()
            };
        }
        public override void Visit(LifetimeScopeScene visitor)
        {
            RegistrationsData = new List<RegistrationData>
            {
                new RegistrationData()
                , _projectScopeRegistry.Scope.RegistrationContainer.CurrentRegistrationData
            };
        }
        
        private static Scene ActiveScene() => SceneManager.GetActiveScene();
    }
}
