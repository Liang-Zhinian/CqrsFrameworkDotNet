using System;
namespace Registration.Contracts
{
    public interface IOrder
    {
        void SetCancelledStatus();
        void SetPaidStatus();
        void SetAwaitingValidationStatus();
        decimal GetTotal();
    }
}
