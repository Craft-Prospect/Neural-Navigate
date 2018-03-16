public class ScoreManager : Energy {

	public static float FeaturesDetected = 0;
	public static float FeaturesPresented = 0;
	

	public static float GetFeaturesDetected(){
		return FeaturesDetected;
	}

	public static void SetFeaturesDetected(int change){
		FeaturesDetected = FeaturesDetected + change;
	}

	public static float GetFeaturesPresented(){
		return FeaturesPresented;
	}

	public static void SetFeaturesPresented(int change){
		FeaturesPresented = FeaturesPresented + change;
	}
}
