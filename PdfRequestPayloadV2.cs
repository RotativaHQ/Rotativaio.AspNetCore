using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rotativaio.AspNetCore
{
    [ProtoContract]
    public class PdfRequestPayloadV2
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        public string Filename { get; set; }

        [ProtoMember(3)]
        public string Switches { get; set; }

        [ProtoMember(4)]
        public Dictionary<string, byte[]> HtmlAssets { get; set; }

        [ProtoMember(5)]
        public string ContentDisposition { get; set; }

        [ProtoMember(6)]
        public bool PdfA { get; set; }
    }
}
