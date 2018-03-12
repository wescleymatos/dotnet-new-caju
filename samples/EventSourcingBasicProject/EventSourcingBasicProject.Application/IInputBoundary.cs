﻿namespace EventSourcingBasicProject.Application
{
    using System.Threading.Tasks;

    public interface IInputBoundary<T>
    {
        Task Process(T request);
    }
}