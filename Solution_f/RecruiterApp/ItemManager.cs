using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace RecruiterApp
{
	public partial class ItemManager
	{
		static ItemManager defaultInstance = new ItemManager();
		MobileServiceClient client;
		IMobileServiceTable<TodoItem> todoTable;//used for testing database remove prior to deployment
        IMobileServiceTable<Position> positionTable;
        IMobileServiceTable<Candidate> candidateTable;
        IMobileServiceTable<CandidatePosition> candidatePositionTable;
        
        //****************************
        private ItemManager()
		{
			client = new MobileServiceClient(
				Constants.ApplicationURL);
			todoTable = client.GetTable<TodoItem>();//remove prior to deployment
            
			try
			{
				positionTable = client.GetTable<Position>();
                candidateTable = client.GetTable<Candidate>();
                candidatePositionTable = client.GetTable<CandidatePosition>();

            }
			catch (Exception ex)
			{
                Debug.WriteLine(ex.Message);
			}
		}

		public static ItemManager DefaultManager
		{
			get
			{
				return defaultInstance;
			}
			private set
			{
				defaultInstance = value;
			}
		}

		public MobileServiceClient CurrentClient
		{
			get { return client; }
		}

        //******************************
        //Database Interactions


        public async Task<ObservableCollection<Position>> GetPositionsAsync(bool syncItems = false) {
            try {
                IEnumerable<Position> items = await positionTable
                    .ToEnumerableAsync();

                return new ObservableCollection<Position>(items);
            }
            catch (MobileServiceInvalidOperationException msioe) {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e) {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        
        public async Task<ObservableCollection<Candidate>> GetCandidatesAsync(bool syncItems = false) {
            try {
                IEnumerable<Candidate> items = await candidateTable
                    
                    .ToEnumerableAsync();

                return new ObservableCollection<Candidate>(items);
            }
            catch (MobileServiceInvalidOperationException msioe) {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e) {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task<ObservableCollection<Candidate>> GetCandidatesForPositionAsync( Position position, bool syncItems = false) {
            try {
                IEnumerable<CandidatePosition> candidatePositions = await candidatePositionTable
                    .Where(cp => cp.PositionId == position.Id && !cp.Deleted)
                    .ToEnumerableAsync();

                List<CandidatePosition> list= candidatePositions.ToList();
                List<string> candIds = new List<string>();
                foreach(CandidatePosition cp in list) {
                    candIds.Add(cp.CandidateId);
                }



                IEnumerable<Candidate> items;
                //if candIDs is empty then items would automatically contain all of the candidates
                //here items are replaced with an empty list with the message
                if (candIds.Count == 0) {
                    List<Candidate> emptyList = new List<Candidate>();
                    emptyList.Add(new Candidate { lastName = "There are no candidates who are currently running for this position" });
                    items = emptyList;
                }
                else {
                    items = await candidateTable
                    .Where(c => candIds.Contains(c.id) && !c.Deleted)
                    .ToEnumerableAsync();

                }

                return new ObservableCollection<Candidate>(items);
            }
            catch (MobileServiceInvalidOperationException msioe) {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e) {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        //Getting all current open positions
        public async Task<ObservableCollection<Position>> GetPositionItemsAsync(bool syncItems = false) {
            try {
                IEnumerable<Position> items = await positionTable
                    .ToEnumerableAsync();

                return new ObservableCollection<Position>(items);
            }
            catch (MobileServiceInvalidOperationException msioe) {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e) {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        //Saving a new Position
        public async Task SaveNewPositionAsync(Position position) {
            if (position.Id == null) {
                await positionTable.InsertAsync(position);
            }
            else {
                await positionTable.UpdateAsync(position);
            }
        }

        //******************************


        //*************************************************************************
        //********************************Remove***********************************

        //remove prior to deployment
        public async Task<ObservableCollection<TodoItem>> GetTodoItemsAsync(bool syncItems = false)
		{
			try
			{
				IEnumerable<TodoItem> items = await todoTable
					.Where(todoItem => !todoItem.Done)
					.ToEnumerableAsync();

				return new ObservableCollection<TodoItem>(items);
			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
			}
			catch (Exception e)
			{
				Debug.WriteLine(@"Sync error: {0}", e.Message);
			}
			return null;
		}
        //remove prior to deployment
		public async Task SaveTaskAsync(TodoItem item)
		{
			if (item.Id == null)
			{
				await todoTable.InsertAsync(item);
			}
			else
			{
				await todoTable.UpdateAsync(item);
			}
		}
        //********************************Remove***********************************
        //*************************************************************************


        
	}
}
