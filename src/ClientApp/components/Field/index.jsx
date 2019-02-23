import React from 'react';
import styles from './styles.css'


const userId = 0


class RedCell extends React.Component {
    render() {
        return (
            <td className={styles.color1} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const colorInt = 2;
        fetch(`/api/game/${userId}/postColor/${colorInt}`,
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
        fetch(`/api/game/${userId}/postColor/${colorInt}`,
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
        fetch(`/api/game/${userId}/postColor/${colorInt}`,
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
        fetch(`/api/game/${userId}/postColor/${colorInt}`,
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
        fetch(`/api/game/${userId}/postColor/${colorInt}`,
            {
                method: "POST"
            })
    }
}

export default class Field extends React.Component {
    constructor(props) {
        super(props);

        this.state = { field: [] };
    }

    componentDidMount() {
        console.log(1)
        fetch(`/api/game/${userId}/getMap`)
            .then(response => response.json())
            .then(response => {
                this.setState({ field: response });
                console.log(response);
            });
    }

    generateNewState = () => {
        console.log(2)
        fetch(`/api/game/${userId}/getMap`)
            .then(response => response.json())
            .then(resp => {
                console.log(resp)
                this.setState({
                    field: resp
                });
            })
    }

    render() {
        return (
            <div onClick={this.generateNewState}>
                {getMarkup(this.state.field)}
            </div>
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
    if (field.length === 0)
        return (<table className={styles.field}></table>);
    // {
    //     if (field[0].length !== 5)
    //         return (<table className={styles.field}></table>);
    //     if (field[1].length !== 5)
    //         return (<table className={styles.field}></table>);
    //     if (field[2].length !== 5)
    //         return (<table className={styles.field}></table>);
    //     if (field[3].length !== 5)
    //         return (<table className={styles.field}></table>);
    //     if (field[4].length !== 5)
    //         return (<table className={styles.field}></table>);
    // }
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