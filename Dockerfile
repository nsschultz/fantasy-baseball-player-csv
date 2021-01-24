# syntax=docker/dockerfile:experimental
FROM nschultz/fantasy-baseball-common-models:0.5.3 AS build
COPY . /app
ENV MAIN_PROJ=FantasyBaseball.PlayerServiceCsv \
    SONAR_KEY=fantasy-baseball-player-csv
RUN --mount=type=cache,id=sonarqube,target=/root/.sonar/cache ./build.sh

FROM nschultz/base-csharp-runner:0.5.3
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "FantasyBaseball.PlayerServiceCsv.dll"]