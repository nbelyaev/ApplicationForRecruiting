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
		IMobileServiceTable<TodoItem> todoTable;
		//IMobileServiceTable<Position> positionTable;

        //****************************
        IMobileServiceTable<Position> positionTable;
        IMobileServiceTable<Candidate> candidateTable;
        IMobileServiceTable<CandidatePosition> candidatePositionTable;

        //static int positions = -1;

        //public async Task<int> countPositions() {
        //    return await positionTable.ToListAsync().Count;
        //}
        //****************************
        private ItemManager()
		{
			this.client = new MobileServiceClient(
				Constants.ApplicationURL);
			this.todoTable = client.GetTable<TodoItem>();
            
			try
			{
				this.positionTable = client.GetTable<Position>();
                this.candidateTable = client.GetTable<Candidate>();
                this.candidatePositionTable = client.GetTable<CandidatePosition>();

            }
			catch (Exception ex)
			{

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
        //public async Task<List<Position>> GetPositionListAsync(bool syncItems = false) {
        //    try {
        //        List<Position> items = await positionTable
        //                .Where(Position => 1==1)
        //                .ToListAsync();

        //        return new List<Position>(items);
        //    }
        //    catch (MobileServiceInvalidOperationException msioe) {
        //        Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
        //    }
        //    catch (Exception e) {
        //        Debug.WriteLine(@"Sync error: {0}", e.Message);
        //    }
        //    return null;
        //}


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


        //public async Task SavePositionAsync(Position item) {
        //    if (item.Id == null) {
        //        await positionTable.InsertAsync(item);
        //    }
        //    else {
        //        await positionTable.UpdateAsync(item);
        //    }
        //}




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
                    .Where(cp => cp.PositionId == position.Id)
                    .ToEnumerableAsync();

                List<CandidatePosition> list= candidatePositions.ToList();
                List<string> candIds = new List<string>();
                foreach(CandidatePosition cp in list) {
                    candIds.Add(cp.CandidateId);
                }



                IEnumerable<Candidate> items = await candidateTable
                    //.Where(c => candidatePositions.Any( id => c.id==id.CandidateId) )
                    .Where(c=> candIds.Contains(c.id))
                    //.Where(c => candIds.Contains(c.id) && candIds.Count!=0)
                    .ToEnumerableAsync();

                if (candIds.Count == 0) {
                    List<Candidate> emptyList = new List<Candidate>();
                    emptyList.Add(new Candidate { lastName = "There are no candidates who are currently running for this position" });
                    items = emptyList;
                }

                //Debug.WriteLine(items.Count());

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

        //******************************






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


		//Getting all current open positions
		public async Task<ObservableCollection<Position>> GetPositionItemsAsync(bool syncItems = false)
		{
			try
			{
				IEnumerable<Position> items = await positionTable
					.ToEnumerableAsync();

				return new ObservableCollection<Position>(items);
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

		//Saving a new Position
		public async Task SaveNewPositionAsync(Position position)
		{
			if (position.Id == null)
			{
				await positionTable.InsertAsync(position);
			}
			else
			{
				await positionTable.UpdateAsync(position);
			}
		}
	}
}
