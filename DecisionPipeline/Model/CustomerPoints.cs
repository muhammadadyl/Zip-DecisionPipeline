namespace DecisionPipeline.Model
{
    public class CustomerPoints
    {
        public int AgeBracketScorePoints { get; set; } = 0;
        public int BureauScorePoints { get; set; } = 0;
        public int MissedPaymentsPoints { get; set; } = 0;
        public int CompletedPaymentsPoints { get; set; } = 0;

        public bool Eligible { get => !(AgeBracketScorePoints < 0 || BureauScorePoints < 0); }

        public int TotalPoints { get => BureauScorePoints + MissedPaymentsPoints + CompletedPaymentsPoints; }

        public int MaxCreditPoints { get => TotalPoints > AgeBracketScorePoints ? AgeBracketScorePoints : TotalPoints; }
        public int CreditAmount { get; internal set; }
    }
}
