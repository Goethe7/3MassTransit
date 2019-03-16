namespace OrderSaga
{
    using System;
    using Contracts;
    using Magnum.StateMachine;
    using MassTransit;
    using MassTransit.Saga;

    // OrderSaga --

    public class OrderSaga : SagaStateMachine<OrderSaga>, ISaga
    {
        static OrderSaga()
        {
            Define(() =>
            {
                Initially(
                    When(Create)
                        .Then((saga, message) => Console.WriteLine("{0}: Order created, sending approval request", message.What))
                        .Publish((saga, message) => new ApproveOrder { Text = message.What, CorrelationId = saga.CorrelationId })
                        .TransitionTo(Approve));
                During(Approve,
                    When(Approved)
                        .Then((saga, message) => Console.WriteLine("{0}: Approval received, sending pick request", message.Text))
                        .Publish((saga, message) => new OrderPick { What = message.Text, CorrelationId = saga.CorrelationId })
                        .TransitionTo(Pick), 
                    When(Rejected)
                        .Complete());
                During(Pick,
                    When(Picked)
                        .Then((saga, message) => Console.WriteLine("{0}: Picking complete, workflow ends", message.Text))
                        .Complete());
            });
        }

        public OrderSaga(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; private set; }
        public IServiceBus Bus { get; set; }
        public static State Initial { get; set; }
        
        private static State Approve => null;

        private static State Pick => null;

        public static State Completed { get; set; }
        private static Event<IOrder> Create => null;

        private static Event<IOrderApproved> Approved => null;

        private static Event<IOrderRejected> Rejected => null;

        private static Event<IPicked> Picked => null;
    }
}
