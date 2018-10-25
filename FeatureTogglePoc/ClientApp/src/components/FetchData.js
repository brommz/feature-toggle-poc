import React, { Component } from 'react';

export class FetchData extends Component {
    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
        var component = this;

        var user = { key: 'user-key' };

        var LDClient = require("ldclient-js");
        var client = LDClient.initialize('secret-key', user);
        client.on('ready', function () {
            var featureEnabled = client.variation("game-forecast-key");
            if (featureEnabled) {
                console.log('external-api');
                component.setState({ externalApi: true });
                FetchData.renderExternalApiMessage();
            }
            else {
                fetch('api/games/forecasts?number=2')
                    .then(response => response.json())
                    .then(data => {
                        component.setState({ externalApi: false, forecasts: data.result, loading: false });
                    });
            }

        });

        client.on('change', function (settings) {
            console.log('flags changed:', settings);
        });
    }

    static renderForecastsTable(forecasts) {
        return (
            <div>
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Points</th>
                            <th>Summary</th>
                        </tr>
                    </thead>
                    <tbody>
                        {forecasts.map(forecast =>
                            <tr key={forecast.dateFormatted}>
                                <td>{forecast.dateFormatted}</td>
                                <td>{forecast.points}</td>
                                <td>{forecast.summary}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    static renderExternalApiMessage(forecasts) {
        return (
            <p>
                External API
            </p>
        );
    }

    render() {
        if (this.state.externalApi) {
            return FetchData.renderExternalApiMessage();
        }

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1>Game forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    _renderExternalForecast() {
        return (
            <p>Here we go!</p>
        );
    }

    componentDidMount() {
            var script = document.createElement('script');
            script.src = "https://app.launchdarkly.com/snippet/ldclient.min.js";
            document.getElementsByTagName('head')[0].appendChild(script);
    }
}
