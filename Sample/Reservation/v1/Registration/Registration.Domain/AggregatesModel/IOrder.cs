using System;
namespace Registration.Domain.AggregatesModel
{
    public interface IOrder
    {
        void SetCancelledStatus();
        void SetPaidStatus();
        void SetAwaitingValidationStatus();
        decimal GetTotal();
    }
}
