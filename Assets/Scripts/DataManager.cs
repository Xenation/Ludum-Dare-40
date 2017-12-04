namespace LD40 {
	public class DataManager : Singleton<DataManager> {

		public DataCenter dataCenter;

		public void Awake() {
			dataCenter = DataCenter.I;
		}

	}
}
