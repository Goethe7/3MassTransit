namespace Contracts
{
    using System;

    using MassTransit;

    public interface IOrder : CorrelatedBy<Guid>
  {
    string What { get; }
    DateTime When { get; }
  }
}
