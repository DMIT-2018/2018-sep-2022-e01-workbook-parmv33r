<Query Kind="Expression" />

//Plan
//1.Check game id not 0
//2.Check team1 count not 0
//3.Check team2 count not 0
//4.Check if gameexist if no throw exception
//5.Get goals home team and visiting team for validation
//6.Check if playerstat already exists for the game if yes rollout throw exception
//7.Get active playerlist of team1
//8.Get active playerlist of team2
//9.Check for zero positive goals and assists on both lists.
//10.Check if sum goals of playingteam 1 == total goals of team in the gamestats
//11.Check if sum goals of playingteam 2 == total goals of team in the gamestats
//12.Add members of both list in one list to process the stats.
//13.Use a loop to process one by one
//14.Select player to update gamesplayed
//15.Check if a player has a goal, assist, red, yellow to add in player stats
//16.If yes create new player record
//17.Do a add to playstat table
