﻿namespace EnglishTraning.DTO
{
    public class EnglishTenesesModel
    {
        public List<EnglishTenesesItem> EnglishTenesesItems {  get; set; } = new List<EnglishTenesesItem>();

        public TensesDropDown TensesDropDown { get; set; } = new TensesDropDown();

        public SentenceTypeDropDown SentenceTypeDropDown { get; set; } = new SentenceTypeDropDown();
    }
}
