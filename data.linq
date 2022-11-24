void RecordGamePlayerStats(int gameid, List<PlayerGameStat> team1, List<Playervoid RecordGamePlayerStats(int gameid, List<PlayerGameStat> team1, List<PlayerGameStat> team2)
{
	Games gameexists  = null;
	PlayerStats playerstatexists = null;

	//we need a container to hold x number of Exception messages
	List<Exception> errorlist = new List<Exception>();
	
	if (gameid == 0)
	{
		throw new Exception("No Game selected");
	}

	if (team1.Count() == 0)
	{
		throw new Exception($"No playerstats to record for {team1}");
	}

	if (team2.Count() == 0)
	{
		throw new Exception($"No playerstats to record for {team2}");
	}

	gameexists = Games
					.Where(x => x.GameID == gameid)
					.FirstOrDefault();
					
	if(gameexists == null)
	{
		throw new ArgumentException("Game does not exist");
	}
	
	int totalgoalsteam1 = gameexists.HomeTeamScore;
	int totalgoalsteam2 = gameexists.VisitingTeamScore;
	
	playerstatexists = PlayerStats
						.Where(x => x.GameID == gameid)
						.Select(x => x)
						.FirstOrDefault();

	if (playerstatexists != null)
	{
		throw new ArgumentException("Playerstats for the selected game already exist");
	}
	
	else
	{
		IEnumerable<PlayerGameStat> playingteam1 = team1
												.Where(x => x.Active);

		IEnumerable<PlayerGameStat> playingteam2 = team2
													.Where(x => x.Active);
													
		IEnumerable<PlayerGameStat> Updatelist = playingteam1.Concat(playingteam2);

		foreach (PlayerGameStat item in Updatelist)
		{
			if (item.Goals < 0)
			{
				errorlist.Add(new Exception($"Goals entered for {item.PlayerID} must be a zero positive number"));
			}

			if (item.Assists < 0)
			{
				errorlist.Add(new Exception($"Assists entered for {item.PlayerID} must be a zero positive number"));
			}
		}

		if (playingteam1.Sum(x => x.Goals) != totalgoalsteam1)
		{
			errorlist.Add(new Exception($"total number of goals by players on a team {gameexists.Home.TeamName} is not equal to the team score recorded for the game."));
		}

		if (playingteam2.Sum(x => x.Goals) != totalgoalsteam2)
		{
			errorlist.Add(new Exception($"total number of goals by players on a team {gameexists.Visiting.TeamName} is not equal to the team score recorded for the game."));
		}

		foreach (PlayerGameStat item in Updatelist)
		{

			Players selectedplayer = Players
											.Where(x => x.PlayerID == item.PlayerID)
											.FirstOrDefault();
			selectedplayer.GamesPlayed++;
			Players.Update(selectedplayer);

//			create a single PlayerStat record only for a player that has a goal, an assist, a yellow card
			//and / or a red card(referred to as a game stat) in this game
			//update each player's record (field: GamesPlayed) if they participated (played) in the game
				//independent of having any stats.

			if (item.Goals != 0 || item.Assists != 0 || item.Red == true || item.Yellow == true)
			{


				PlayerStats player = new PlayerStats()
				{
					GameID = gameid,
					PlayerID = item.PlayerID,
					Goals = item.Goals,
					Assists = item.Assists,
					RedCard = item.Red,
					YellowCard = item.Yellow,
				};

				PlayerStats.Add(player);
			}

		}
	}

	if (errorlist.Count > 0)
	{
		throw new AggregateException("Unable to register stats. Check concerns", errorlist);
	}
	else
	{
		Console.WriteLine("PlayerStats added successfully!!");
		SaveChanges();
	}

}GameStat> team2)
{
    Games gameexists  = null;
    PlayerStats playerstatexists = null;

    //we need a container to hold x number of Exception messages
    List<Exception> errorlist = new List<Exception>();
    
    if (gameid == 0)
    {
        throw new Exception("No Game selected");
    }

    if (team1.Count() == 0)
    {
        throw new Exception($"No playerstats to record for {team1}");
    }

    if (team2.Count() == 0)
    {
        throw new Exception($"No playerstats to record for {team2}");
    }

    gameexists = Games
                    .Where(x => x.GameID == gameid)
                    .FirstOrDefault();
                    
    if(gameexists == null)
    {
        throw new ArgumentException("Game does not exist");
    }
    
    int totalgoalsteam1 = gameexists.HomeTeamScore;
    int totalgoalsteam2 = gameexists.VisitingTeamScore;
    
    playerstatexists = PlayerStats
                        .Where(x => x.GameID == gameid)
                        .Select(x => x)
                        .FirstOrDefault();

    if (playerstatexists != null)
    {
        throw new ArgumentException("Playerstats for the selected game already exist");
    }
    
    else
    {
        IEnumerable<PlayerGameStat> playingteam1 = team1
                                                .Where(x => x.Active);

        IEnumerable<PlayerGameStat> playingteam2 = team2
                                                    .Where(x => x.Active);
                                                    
        IEnumerable<PlayerGameStat> Updatelist = playingteam1.Concat(playingteam2);

        foreach (PlayerGameStat item in Updatelist)
        {
            if (item.Goals < 0)
            {
                errorlist.Add(new Exception($"Goals entered for {item.PlayerID} must be a zero positive number"));
            }

            if (item.Assists < 0)
            {
                errorlist.Add(new Exception($"Assists entered for {item.PlayerID} must be a zero positive number"));
            }
        }

        if (playingteam1.Sum(x => x.Goals) != totalgoalsteam1)
        {
            errorlist.Add(new Exception($"total number of goals by players on a team {gameexists.Home.TeamName} is not equal to the team score recorded for the game."));
        }

        if (playingteam2.Sum(x => x.Goals) != totalgoalsteam2)
        {
            errorlist.Add(new Exception($"total number of goals by players on a team {gameexists.Visiting.TeamName} is not equal to the team score recorded for the game."));
        }

        foreach (PlayerGameStat item in Updatelist)
        {

            Players selectedplayer = Players
                                            .Where(x => x.PlayerID == item.PlayerID)
                                            .FirstOrDefault();
            selectedplayer.GamesPlayed++;
            Players.Update(selectedplayer);

//            create a single PlayerStat record only for a player that has a goal, an assist, a yellow card
            //and / or a red card(referred to as a game stat) in this game
            //update each player's record (field: GamesPlayed) if they participated (played) in the game
                //independent of having any stats.

            if (item.Goals != 0 || item.Assists != 0 || item.Red == true || item.Yellow == true)
            {


                PlayerStats player = new PlayerStats()
                {
                    GameID = gameid,
                    PlayerID = item.PlayerID,
                    Goals = item.Goals,
                    Assists = item.Assists,
                    RedCard = item.Red,
                    YellowCard = item.Yellow,
                };

                PlayerStats.Add(player);
            }

        }
    }

    if (errorlist.Count > 0)
    {
        throw new AggregateException("Unable to register stats. Check concerns", errorlist);
    }
    else
    {
        Console.WriteLine("PlayerStats added successfully!!");
        SaveChanges();
    }

}

