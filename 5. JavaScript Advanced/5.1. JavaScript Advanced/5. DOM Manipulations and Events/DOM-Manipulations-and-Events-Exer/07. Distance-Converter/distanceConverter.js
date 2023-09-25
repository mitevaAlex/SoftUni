function attachEventsListeners() {
    let convertBtn = document.getElementById('convert');
    convertBtn.addEventListener('click', convert);

    function convert(event) {
        let inputValue = Number(document.getElementById('inputDistance').value);
        let inputUnit = document.getElementById('inputUnits').value;
        let outputUnit = document.getElementById('outputUnits').value;
        let inputValueInMeters = converterFromAndToMeters(inputValue, 'to', inputUnit);
        let outputValue = converterFromAndToMeters(inputValueInMeters, 'from', outputUnit);
        document.getElementById('outputDistance').value = outputValue;
        
        function converterFromAndToMeters(value, operation, unit) {
            let convertNum = 0;
            switch (unit) {
                case 'km':
                    convertNum = 1000;
                    break;
                case 'm':
                    convertNum = 1;
                    break;
                case 'cm':
                    convertNum = 0.01;
                    break;
                case 'mm':
                    convertNum = 0.001;
                    break;
                case 'mi':
                    convertNum = 1609.34;
                    break;
                case 'yrd':
                    convertNum = 0.9144;
                    break;
                case 'ft':
                    convertNum = 0.3048;
                    break;
                case 'in':
                    convertNum = 0.0254;
                    break;
            }

            let result = 0;
            if (operation === 'to') {
                result = value * convertNum;
            } else if (operation === 'from') {
                result = value / convertNum;
            }

            return result;
        }
    }
}