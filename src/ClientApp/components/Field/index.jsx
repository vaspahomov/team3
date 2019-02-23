import React from 'react';
import styles from './styles.css'

class RedCell extends React.Component {
    render() {
        return (
            <td className={styles.color1} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const value = extractNumberString(event.target.value);
    }
}
class GreenCell extends React.Component {
    render() {
        return (
            <td className={styles.color2} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const value = extractNumberString(event.target.value);
    }
}
class CyanCell extends React.Component {
    render() {
        return (
            <td className={styles.color3} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const value = extractNumberString(event.target.value);
    }
}
class MagentaCell extends React.Component {
    render() {
        return (
            <td className={styles.color4} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const value = extractNumberString(event.target.value);
    }
}
class BlueCell extends React.Component {
    render() {
        return (
            <td className={styles.color5} onClick={this.handlerOnClick}></td>
        )
    }

    handlerOnClick = event => {
        const value = extractNumberString(event.target.value);
    }
}

export default class Field extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            field: [
                [

                ]
            ]
        }
    }



    render() {
        return (
            <table className={styles.field}>

                <tr>
                    {/* Это строчка на поле */}
                    <RedCell />
                    {/* Это ячейка на поле. Класс color1...color5 задает цвет ячейки. Цвета можно изменить в файле styles.css */}
                    <RedCell />
                    <GreenCell />
                    <RedCell />
                    <CyanCell />
                    {/* Клеток в строках может быть сколько угодно, они будут пропорционально
                менять размер, в зависимости от количества.
                Для того, чтобы верстка работала корректно, нужно, чтобы количество клеток в разных строках было
                одинаково. */}
                </tr>
                <tr>
                    <BlueCell />
                    <CyanCell />
                    <MagentaCell />
                    <RedCell />
                    <CyanCell />
                </tr>
                <tr>
                    <RedCell />
                    <MagentaCell />
                    <BlueCell />
                    <MagentaCell />
                    <RedCell />
                </tr>
                <tr>
                    <RedCell />
                    <RedCell />
                    <MagentaCell />
                    <RedCell />
                    <CyanCell />
                </tr>
                <tr>
                    <CyanCell />
                    <RedCell />
                    <MagentaCell />
                    <CyanCell />
                    <BlueCell />
                </tr>
            </table>
        );
    }
}
