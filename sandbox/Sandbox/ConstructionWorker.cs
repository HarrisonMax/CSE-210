class ConstructionWorker : Employee
{
    public ConstructionWorker(string name, double hours, double wage): base(name, hours, wage)
    {

    }

    public double GetPay()
    {
        return base.GetPay() + 1000;
    }
    public override double InsuranceCost()
    {
        return base.GetPay() * 4;
    }
}