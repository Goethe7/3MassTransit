namespace Contracts
{
    using System;

    using MassTransit;

    public interface IPicked : CorrelatedBy<Guid>
    {
        string Text { get; set; }
    }
}