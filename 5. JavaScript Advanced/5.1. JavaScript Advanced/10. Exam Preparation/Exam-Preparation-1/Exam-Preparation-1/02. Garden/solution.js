class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {
        if (this.spaceAvailable < spaceRequired) {
            throw new Error('Not enough space in the garden.');
        }

        let plant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        };
        this.plants.push(plant);
        this.spaceAvailable -= spaceRequired;
        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant(plantName, quantity) {
        let plant = this.plants.find(x => x.plantName === plantName);
        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe === true) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error('The quantity cannot be zero or negative.');
        }

        plant.ripe = true;
        plant.quantity += quantity;

        if (quantity == 1) {
            return `${quantity} ${plantName} has successfully ripened.`
        } else if (quantity > 1) {
            return `${quantity} ${plantName}s have successfully ripened.`
        }
    }

    harvestPlant(plantName) {
        let plant = this.plants.find(x => x.plantName === plantName);
        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe === false) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.storage.push({ plantName, quantity: plant.quantity });
        this.spaceAvailable += plant.spaceRequired;
        this.plants = this.plants.filter(x => x.plantName !== plantName);
        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport() {
        let result = `The garden has ${this.spaceAvailable} free space left.\n`;
        result += `Plants in the garden: ${this.plants.map(x => x.plantName).sort().join(', ')}\n`;
        if (this.storage.length == 0) {
            result += 'Plants in storage: The storage is empty.';
        } else {
            result += `Plants in storage: ${this.storage.map(x => `${x.plantName} (${x.quantity})`).join(', ')}`;
        }

        return result;
    }
}

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('olive', 50));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('orange', 4));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('olive', 30));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('cucumber', -5));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('apple'));
// console.log(myGarden.harvestPlant('olive'));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('apple'));
// console.log(myGarden.harvestPlant('raspberry'));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('orange'));
// console.log(myGarden.generateReport());
