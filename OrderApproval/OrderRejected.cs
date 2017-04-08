namespace OrderApproval
{
    using System;

    using Contracts;

    public class OrderRejected : IOrderRejected
    {
        public string Text { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
