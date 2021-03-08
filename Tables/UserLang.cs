using System;
using System.Collections.Generic;

#nullable disable

namespace HrAdm.Tables
{
    public partial class UserLang
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string LangName { get; set; }
        public byte ListenLevel { get; set; }
        public byte SpeakLevel { get; set; }
        public byte ReadLevel { get; set; }
        public byte WriteLevel { get; set; }
        public int Sort { get; set; }
    }
}
