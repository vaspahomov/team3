import React from 'react';
import styles from './styles.css'

const deployServerUrl = 'http://gamehack3.azurewebsites.net/'
const testServerUrl = 'https://localhost:5001/'
const userId = 0

const serv = testServerUrl;


class RedCell extends React.Component {
    render() {
        return (
            <td className={styles.color1} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const colorInt = 1;
        fetch(serv + `api/game/${userId}/postColor/${colorInt}`,
            {
                method: "POST"
            })
    }
}
class GreenCell extends React.Component {
    render() {
        return (
            <td className={styles.color2} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const colorInt = 2;
        fetch(serv + `api/game/${userId}/postColor/${colorInt}`,
            {
                method: "POST"
            })
    }
}
class CyanCell extends React.Component {
    render() {
        return (
            <td className={styles.color3} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const colorInt = 3;
        fetch(serv + `api/game/${userId}/postColor/${colorInt}`,
            {
                method: "POST"
            })
    }
}
class MagentaCell extends React.Component {
    render() {
        return (
            <td className={styles.color4} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const colorInt = 4;
        fetch(serv + `api/game/${userId}/postColor/${colorInt}`,
            {
                method: "POST"
            })
    }
}
class BlueCell extends React.Component {
    render() {
        return (
            <td className={styles.color5} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const colorInt = 5;
        fetch(serv + `api/game/${userId}/postColor/${colorInt}`,
            {
                method: "POST"
            })
    }
}

export default class Field extends React.Component {
    constructor(props) {
        super(props);

        fetch(serv + `api/game/${userId}/startGame`,
            {
                method: "POST",
                body: {
                    "h": "5",
                    "w": "5",
                    "colorCount": "5",
                }
            })
            .catch(x=> console.log(x));


        let resp = fetch(serv + `api/game/${userId}/getMap`)
            .then(response => response.json())
            .catch(x=> console.log(x));


        console.log(resp)

        this.state = {
            field: [
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
            ]
        }
    }

    randomGenerate = setInterval(() => {
        this.setState = {
            field: [
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
                [getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5), getRandomInt(1, 5)],
            ]
        }
    }, 1000);

    render() {
        return (
            getMarkup(this.state.field)
        );
    }
}

function getRandomInt(min, max) {
    return Math.round(Math.random() * (max - min) + min);
}

function getSingleMarkup(colorValue) {
    switch (colorValue) {
        case 1:
            return <RedCell />
        case 2:
            return <GreenCell />
        case 3:
            return <CyanCell />
        case 4:
            return <MagentaCell />
        case 5:
            return <BlueCell />
        default:
            return <div />
    }
}

function getMarkup(field) {
    return (
        <table className={styles.field}>
            <tr>
                {getSingleMarkup(field[0][0])}
                {getSingleMarkup(field[0][1])}
                {getSingleMarkup(field[0][2])}
                {getSingleMarkup(field[0][3])}
                {getSingleMarkup(field[0][4])}
                {/* Клеток в строках может быть сколько угодно, они будут пропорционально
                менять размер, в зависимости от количества.
                Для того, чтобы верстка работала корректно, нужно, чтобы количество клеток в разных строках было
                одинаково. */}
            </tr>
            <tr>
                {getSingleMarkup(field[1][0])}
                {getSingleMarkup(field[1][1])}
                {getSingleMarkup(field[1][2])}
                {getSingleMarkup(field[1][3])}
                {getSingleMarkup(field[1][4])}
            </tr>
            <tr>
                {getSingleMarkup(field[2][0])}
                {getSingleMarkup(field[2][1])}
                {getSingleMarkup(field[2][2])}
                {getSingleMarkup(field[2][3])}
                {getSingleMarkup(field[2][4])}
            </tr>
            <tr>
                {getSingleMarkup(field[3][0])}
                {getSingleMarkup(field[3][1])}
                {getSingleMarkup(field[3][2])}
                {getSingleMarkup(field[3][3])}
                {getSingleMarkup(field[3][4])}
            </tr>
            <tr>
                {getSingleMarkup(field[4][0])}
                {getSingleMarkup(field[4][1])}
                {getSingleMarkup(field[4][2])}
                {getSingleMarkup(field[4][3])}
                {getSingleMarkup(field[4][4])}
            </tr>
        </table>
    );
}