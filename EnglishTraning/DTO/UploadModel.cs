namespace EnglishTraning.DTO
{
    public class UploadModel
    {
        public TensesDropDown TensesDropDown { get; set; } = new TensesDropDown();

        public SentenceTypeDropDown SentenceTypeDropDown { get; set; } = new SentenceTypeDropDown();
    }
}
