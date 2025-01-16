namespace EnglishTraning.DTO
{
    public class SentenceTypeDropDown
    {

        public string SelectedSentenceTypeName { get; set; }

        public List<DropDownItem> SentenceTypes { get; set; } = new List<DropDownItem>();
    }
}
