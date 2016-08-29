using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class CandidatePosition
	{
        //int id;
        //int positionId;
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "candidateId")]
		public string CandidateId { get; set; }

		[JsonProperty(PropertyName = "positionId")]
		public string PositionId { get; set; }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }
        
    }
}

