import React from 'react';
import styles from './styles.css'


export default class Field extends React.Component {
    render () {
        return (
            <table className={styles.field}>

            <tr> 
            {/* Это строчка на поле */}
                <td className={styles.color2}></td> 
                {/* Это ячейка на поле. Класс color1...color5 задает цвет ячейки. Цвета можно изменить в файле styles.css */}
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td> 
                {/* Клеток в строках может быть сколько угодно, они будут пропорционально
                менять размер, в зависимости от количества.
                Для того, чтобы верстка работала корректно, нужно, чтобы количество клеток в разных строках было
                одинаково. */}
            </tr>
            <tr>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color1}></td>
                <td className={styles.color2}></td>
            </tr>
            <tr>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
            </tr>
            <tr>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
            </tr>
            <tr>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
                <td className={styles.color2}></td>
            </tr>
        </table>
        );
    }
}
