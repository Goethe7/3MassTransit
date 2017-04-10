namespace Contracts
{
    using System;
    using MassTransit;

    public interface IOrderApproved : CorrelatedBy<Guid>
    {
        string Text { get; set; }
    }
}