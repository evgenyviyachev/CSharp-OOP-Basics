using System;

public abstract class HouseHold
{
    private int numberOfRooms;
    private decimal roomElectricity;
    private readonly decimal income;
    private decimal money;

    protected HouseHold(decimal income, int numberOfRooms, decimal roomElectricity)
    {
        this.income = income;
        this.numberOfRooms = numberOfRooms;
        this.roomElectricity = roomElectricity;
        this.money = 0;
    }

    public virtual int Population
    {
        get
        {
            return 1;
        }
    }

    public virtual decimal Consumption
    {
        get
        {
            return this.numberOfRooms * this.roomElectricity;
        }
    }

    public void GetIncome()
    {
        this.money += this.income;
    }

    public bool CanPayBills()
    {
        return this.money >= this.Consumption;
    }

    public void PayBills()
    {
        if (this.CanPayBills())
        {
            this.money -= this.Consumption;
        }
    }
}