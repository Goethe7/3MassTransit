namespace OrderSaga
{
    using System;

    using Contracts;

    public class OrderPick : IPick
    {
        public string What { get; set; }

        public Guid CorrelationId { get; set; }
    }
}
