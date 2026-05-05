# FaHIcon

FaHIcon is a small API that generates embeddable SVG badge icons displaying [Folding@Home](https://foldingathome.org/) statistics for a given user.

## Base URL

```
https://fah.dansi.dev
```

---

## Endpoints

### `GET /health`

Returns a simple health check message confirming the service is running.

**Response:** `200 OK` — plain text with the current UTC timestamp.

**Example:**
```
GET https://fah.dansi.dev/health
```

---

### `GET /icon/points`

Returns an SVG badge showing the total Folding@Home **points** earned by a user.

**Query Parameters:**

| Parameter | Type   | Required | Description                        |
|-----------|--------|----------|------------------------------------|
| `userId`  | string | ✅ Yes   | The Folding@Home username to look up |

**Response:** `200 OK` — an `image/svg+xml` SVG badge.

Large numbers are automatically abbreviated (e.g. `1,500,000` → `1.5M`).

**Example URL:**
```
https://fah.dansi.dev/icon/points?userId=dansi21
```

**Embed in Markdown:**
```markdown
![F@H Points](https://fah.dansi.dev/icon/points?userId=dansi21)
```

**Embed in HTML:**
```html
<img src="https://fah.dansi.dev/icon/points?userId=dansi21" alt="F@H Points" />
```

---

### `GET /icon/leaderboard`

Returns an SVG badge showing the **leaderboard rank** of a user.

**Query Parameters:**

| Parameter | Type   | Required | Description                        |
|-----------|--------|----------|------------------------------------|
| `userId`  | string | ✅ Yes   | The Folding@Home username to look up |

**Response:** `200 OK` — an `image/svg+xml` SVG badge.

**Example URL:**
```
https://fah.dansi.dev/icon/leaderboard?userId=dansi21
```

**Embed in Markdown:**
```markdown
![F@H Rank](https://fah.dansi.dev/icon/leaderboard?userId=dansi21)
```

**Embed in HTML:**
```html
<img src="https://fah.dansi.dev/icon/leaderboard?userId=dansi21" alt="F@H Rank" />
```

---

## Usage Example

Show both badges side by side in a GitHub profile README:

```markdown
[![F@H Points](https://fah.dansi.dev/icon/points?userId=dansi21)](https://stats.foldingathome.org/donor/dansi21)
[![F@H Rank](https://fah.dansi.dev/icon/leaderboard?userId=dansi21)](https://stats.foldingathome.org/donor/dansi21)
```

---

## Notes

- User data is cached for **5 minutes** to avoid excessive requests to the Folding@Home API.
- If the provided `userId` does not exist on Folding@Home, the API returns an error.
