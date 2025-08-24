﻿namespace App.Scripts.Infrastructure.Pool
{
    public sealed class ObjectPoolContainer<T>
    {
        public bool Used { get; private set; }
        public float Time { get; set; }
        public T Item { get; set; }

        public void Consume()
        {
            Used = true;
        }

        public void Release()
        {
            Used = false;
        }
    }
}