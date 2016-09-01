using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace RecruiterApp
{
	public class Candidate
	{
		public Candidate()
		{
		}

        public string nameString {
            get{
                return lastName + ", " + firstName;
            }
        }

        public string addressString {//figure out how to pull state first
            get {
                return state.StateName ;
                //return " this is a string";
            }
        }

        [Key]
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string firstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string lastName { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }
        [JsonProperty(PropertyName = "street")]
        public string street { get; set; }
        [JsonProperty(PropertyName = "street2")]
        public string street2 { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string city { get; set; }
        [JsonProperty(PropertyName = "zip")]
        public string zip { get; set; }


        //public string stateId { get; set; }
        [JsonProperty(PropertyName = "state")]
        public virtual State state { get; set; }


        public int recruiterContactId { get; set; }
        public int sourceId { get; set; }
        public DateTime creationTime { get; set; }
        public bool hasResume { get; set; }
        public string candidateInfoNotes { get; set; }
        public string recommendedBy { get; set; }
        public bool hasCompletedApplication { get; set; }
        public bool hasDetailsAndReferences { get; set; }
        public bool hasCompletedAdp { get; set; }
        public string completedApplicationComments { get; set; }
        public string detailsAndReferencesComments { get; set; }
        public string verbalOfferComments { get; set; }
        public string formalOfferComments { get; set; }
        public string clearedBackgroundComments { get; set; }
        public string sogetiResumeComments { get; set; }


        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }
        [Version]
        public string Version { get; set; }
    }
}

