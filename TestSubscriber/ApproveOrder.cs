namespace OrderSaga
{
    using System;
    using Contracts;

    public class ApproveOrder : IApproveOrder
    {
        public string Text { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
