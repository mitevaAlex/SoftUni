function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);
    function onClick() {
        let inputArray = JSON.parse(document.querySelector('#inputs textarea').value);
        let restaurants = [];
        for (let restaurantInfo of inputArray) {
            restaurantInfo = restaurantInfo.split(/ - |, | /);
            let workers = restaurantInfo.map((worker, index) => {
                if (index % 2 == 1) {
                    return {
                        name: worker,
                        salary: Number(restaurantInfo[index + 1])
                    }
                }
            }).filter(x => x !== undefined);
            if (restaurants.hasOwnProperty(restaurantInfo[0])) {
                restaurants[restaurantInfo[0]].workers.push(...workers);
            } else {
                restaurants[restaurantInfo[0]] = {
                    workers,
                    averageSalary() {
                        return this.workers.reduce((sum, worker) => sum += worker.salary, 0) / this.workers.length;
                    },
                    bestSalary() {
                        return Math.max(...this.workers.map(worker => worker.salary));
                    }
                }
            }
        }

        let bestRestaurantName = Object.keys(restaurants)[0];
        for (let restaurantName in restaurants) {
            if (restaurants[restaurantName].averageSalary() > restaurants[bestRestaurantName].averageSalary()) {
                bestRestaurantName = restaurantName;
            }
        }

        restaurants[bestRestaurantName].workers.sort((a, b) => b.salary - a.salary);
        document.querySelector('#bestRestaurant p').textContent = `Name: ${bestRestaurantName} Average Salary: ${restaurants[bestRestaurantName].averageSalary().toFixed(2)} Best Salary: ${restaurants[bestRestaurantName].bestSalary().toFixed(2)}`
        document.querySelector('#workers p').textContent = `${restaurants[bestRestaurantName].workers.map(x => `Name: ${x.name} With Salary: ${x.salary}`).join(' ')}`;
    }
}