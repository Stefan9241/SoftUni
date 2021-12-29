function solve(area, vol, input) {
        let parsedInput = JSON.parse(input);

        let result = [];

        for (const obj of parsedInput) {
            let objArea = area.apply(obj);
            let objVolume = vol.apply(obj);

            result.push({
                area: objArea,
                volume: objVolume
            });
        }

        return result;
}

function vol() {
    return Math.abs(this.x * this.y * this.z);
};
function area() {
    return Math.abs(this.x * this.y);
};