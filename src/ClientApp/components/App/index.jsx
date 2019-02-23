import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor() {
        super();
        this.state = {
            score: 0,
        };
    }

    render() {
        return (
            <div className={styles.root} onClick={this.handleScore}>
                <div className={styles.score}>
                    Ваш счет: {this.state.score}
                </div>
                <Field />
            </div>
        );
    }

    handleScore = () => {
        let userId = 0;
        fetch(`/api/game/${userId}/score`)
            .then(response => response.json())
            .then(response => {
                this.setState({ score: response });
            });
    }

}
