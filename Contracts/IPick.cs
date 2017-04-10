namespace Contracts
{
    using System;
    using MassTransit;

    public interface IPick : CorrelatedBy<Guid>
    {
         string What { get; set; }
    }
}