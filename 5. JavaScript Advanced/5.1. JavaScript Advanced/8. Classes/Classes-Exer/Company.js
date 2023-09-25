class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!');
        }

        let employee = { name, salary, position };
        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [];
        }

        this.departments[department].push(employee);
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartmentName;
        let bestAvgSalary = 0;
        for (let departmentName in this.departments) {
            let avgSalary = this.departments[departmentName].map(x => x.salary).reduce((sum, x) => sum += x) / this.departments[departmentName].length;
            if (avgSalary > bestAvgSalary) {
                bestAvgSalary = avgSalary;
                bestDepartmentName = departmentName;
            }
        }

        let result = `Best Department is: ${bestDepartmentName}\nAverage salary: ${bestAvgSalary.toFixed(2)}\n`;
        this.departments[bestDepartmentName]
            .sort((a, b) => {
                if (b.salary > a.salary) return 1;
                if (b.salary < a.salary) return -1;
                if (a.name > b.name) return 1;
                if (a.name < b.name) return -1;
            });
        result += this.departments[bestDepartmentName]
            .map(x => `${x.name} ${x.salary} ${x.position}`)
            .join('\n');
        return result;
    }
}

// let c = new Company();
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");
// console.log(c.bestDepartment());