# FaHIcon

FaHIcon is a small API that generates dynamic SVG badges for your [Folding@Home](https://foldingathome.org/) (F@H) statistics. Embed them in your GitHub profile README to show off your contribution to disease research.

---

## Available Badges

### F@H Points

Shows your total Folding@Home points.

```
GET /icon/points?userId={your_fah_username}
```

**Preview:**

![F@H Points](https://raw.githubusercontent.com/dansi21/FaHIcon/refs/heads/main/docs/points-badge.svg)

---

### F@H Leaderboard Rank

Shows your global rank on the Folding@Home leaderboard.

```
GET /icon/leaderboard?userId={your_fah_username}
```

**Preview:**

![F@H Rank](https://raw.githubusercontent.com/dansi21/FaHIcon/refs/heads/main/docs/rank-badge.svg)

---

## Using Badges on Your GitHub Profile

GitHub profile READMEs are Markdown files (`README.md`) inside a repository named after your GitHub username (e.g. `github.com/your-username/your-username`).

### Step 1 – Find your Folding@Home username

Your F@H username is the name you registered with at [foldingathome.org](https://foldingathome.org/). It is case-sensitive. You can confirm it by visiting:

```
https://api.foldingathome.org/user/{your_fah_username}
```

### Step 2 – Add the badges to your profile README

Paste the following Markdown into your profile `README.md`, replacing `your_fah_username` with your actual username and `your-host` with the URL of a running FaHIcon instance:

```markdown
![F@H Points](https://your-host/icon/points?userId=your_fah_username)
![F@H Rank](https://your-host/icon/leaderboard?userId=your_fah_username)
```

You can also wrap them in links to your F@H stats page:

```markdown
[![F@H Points](https://your-host/icon/points?userId=your_fah_username)](https://stats.foldingathome.org/donor/your_fah_username)
[![F@H Rank](https://your-host/icon/leaderboard?userId=your_fah_username)](https://stats.foldingathome.org/donor/your_fah_username)
```

> **Note:** GitHub caches external images. If your badge does not update immediately, append `?v=1` (or any unique query string) to bust the cache, or wait for GitHub's CDN to refresh.

---

## Self-Hosting

You need a publicly reachable host for the badges to display on GitHub. Two options are provided below.

### Option A – Docker (recommended)

**Prerequisites:** [Docker](https://docs.docker.com/get-docker/)

```bash
# Build the image
docker build -t fahicon -f FaHIconAPI/Dockerfile .

# Run on port 8080
docker run -d -p 8080:8080 --name fahicon fahicon
```

The API will be available at `http://localhost:8080`. Deploy the container to any cloud provider (Azure App Service, Railway, Fly.io, etc.) and use that public URL in your badge Markdown.

### Option B – Run locally with .NET

**Prerequisites:** [.NET 9 SDK](https://dotnet.microsoft.com/download)

```bash
cd FaHIconAPI
dotnet run
```

The API starts on `https://localhost:7014` by default (see `appsettings.Development.json`). This is suitable for local testing only; you will need a tunnel (e.g. [ngrok](https://ngrok.com/)) or a public deployment to use the badges on GitHub.

---

## API Reference

| Endpoint | Query Parameter | Response |
|---|---|---|
| `GET /icon/points` | `userId` – your F@H username | SVG badge showing your total points |
| `GET /icon/leaderboard` | `userId` – your F@H username | SVG badge showing your global rank |

Responses are `image/svg+xml` and are cached server-side for **5 minutes** to avoid hammering the F@H API.

---

## Example

```markdown
## ⚗️ Folding@Home Stats

[![F@H Points](https://your-host/icon/points?userId=dansi21)](https://stats.foldingathome.org/donor/dansi21)
[![F@H Rank](https://your-host/icon/leaderboard?userId=dansi21)](https://stats.foldingathome.org/donor/dansi21)
```