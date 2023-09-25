class FootballTeam{
    constructor(clubName, country){
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers){
        let names = [];
        for(let playerInfo of footballPlayers){
            let [name, age, playerValue] = playerInfo.split('/');
            age = Number(age);
            playerValue = Number(playerValue);
            let player = this.invitedPlayers.find(x => x.name === name);
            if(!player){
                this.invitedPlayers.push({name, age, playerValue});
                names.push(name);
            } else if (player.playerValue < playerValue) {
                player.playerValue = playerValue;
            }
        }

        return `You successfully invite ${names.join(', ')}.`
    }

    signContract(selectedPlayer){
        let [name, playerOffer] = selectedPlayer.split('/');
        playerOffer = Number(playerOffer);
        let player = this.invitedPlayers.find(x => x.name === name);
        if(!player){
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if(player.playerValue > playerOffer){
            let priceDifference = player.playerValue - playerOffer;
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`);
        }

        player.playerValue = 'Bought';
        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }

    ageLimit(name, age){
        let player = this.invitedPlayers.find(x => x.name === name);
        if(!player){
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if(player.age < age){
            let difference = age - player.age;
            if(difference < 5){
                return `${name} will sign a contract for ${difference} years with ${this.clubName} in ${this.country}!`
            } else {
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        } else {
            return `${name} is above age limit!`;
        }
    }

    transferWindowResult(){
        let result = 'Players list:';
        this.invitedPlayers.sort((a,b) => a.name.localeCompare(b.name));
        result += '\n' + `${this.invitedPlayers.map(x => `Player ${x.name}-${x.playerValue}`).join('\n')}`;
        return result;
    }
}