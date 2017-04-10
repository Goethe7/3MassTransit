namespace Contracts
{
    using System;

    using MassTransit;

    public interface IOrderRejected : CorrelatedBy<Guid>
    {
        string Text { get; set; } 
    }
}