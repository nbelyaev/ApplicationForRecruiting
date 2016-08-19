using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class CandidatePosition
	{
		int id;
		int positionId;

		[JsonProperty(PropertyName = "CandidatePositionId")]
		public int CandidatePositionId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "PositionId")]
		public int PositionId { get { return this.positionId; } set { this.positionId = value; } }
	}
}

