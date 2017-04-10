namespace Contracts
{
    using System;

    using MassTransit;

    public interface IApproveOrder : CorrelatedBy<Guid>
    {
        string Text { get; set; } 
    }
}