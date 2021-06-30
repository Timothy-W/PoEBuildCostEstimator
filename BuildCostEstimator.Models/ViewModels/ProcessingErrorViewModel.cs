using System;
using System.ComponentModel;

namespace BuildCostEstimator.Models.ViewModels
{
    public class ProcessingErrorViewModel
    {
        [DisplayName("Pastebin Link")]
        public string PastebinLink { get; set; }
        [DisplayName("Error Message")]
        public string Message { get; set; }

        public bool ShowPastebinLink => !string.IsNullOrEmpty(PastebinLink);
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
    }
}
