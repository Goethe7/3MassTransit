namespace OrderApproval
{
    using System;

    using Contracts;

    public class OrderApproved : IOrderApproved
    {
        public string Text { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
