namespace PickService
{
    using System;
    using Contracts;

    public class OrderPicked : IPicked
    {
        public Guid CorrelationId { get; set; }
        public string Text { get; set; }
    }
}
