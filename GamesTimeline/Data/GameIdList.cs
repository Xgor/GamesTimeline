using Newtonsoft.Json;

namespace GamesTimeline.Data;

public class GameIdList
{
    /*
    public static GameIdList LoadJson(string filePath)
    {
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            List<int> items = JsonConvert.DeserializeObject<List<int>>(json);
            var list = new GameIdList();

        }
    }
*/
    private List<int> publishedIds { get; init; }
}