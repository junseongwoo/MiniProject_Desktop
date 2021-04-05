using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;

namespace NaverMovieFinderApp
{

    public partial class TrailerWindow : MetroWindow
    {
        List<YoutubeItem> youtubes; // 유튜브 api 검색결과 담을 리스트

        public TrailerWindow()
        {
            InitializeComponent();
        }

        public TrailerWindow(string movieName) : this()
        {
            LblMovieName.Content = $"{movieName} 예고편";
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 유튜브 API로 검색
            //MessageBox.Show("유튜브 검색!");
            ProcSearchYoutubeApi();
        }

        private async void ProcSearchYoutubeApi()
        { 
            await LoadDataCollection();
        }

        private async Task LoadDataCollection()
        {
            var youtubeService = new YouTubeService(
                new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyAgA2T8-gYSqc6o75H2nXabMoFF-qFg34k",
                    ApplicationName = this.GetType().ToString()

                }) ;

            // TODO ; 
        }
    }
}
