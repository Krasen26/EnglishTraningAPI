namespace EnglishTraning.DTO
{
    public class TensesDropDown
    {
        public string SelectedTenseName { get; set; }

        public List<DropDownItem> TensesItems { get; set; } = new List<DropDownItem>();
    }
}
