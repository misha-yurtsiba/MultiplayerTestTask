# Architecture Notes

## Current Architecture

The current project uses **Photon Fusion in Host Mode**.  
One player acts as the host and runs the simulation while other players connect as clients.

**Key components:**

- **NetworkService** – manages the multiplayer session
- **PlayerNetworkSpawner** – spawns player objects when users join
- **VoicePlayerController** – implemented using Photon Voice

This architecture works well for small sessions (2–10 players) but would require changes to reliably support 100 concurrent users.

---

### Changes Required to Support 100 Concurrent Users

### 1. Dedicated Server Architecture

Host Mode should be replaced with **Server Mode** using a dedicated server instance.


- Host players leaving would no longer terminate the session
- Simulation performance becomes consistent
- Better control over CPU/network resources

---

### 2. Interest Management

With 100 players, sending updates about every player to every client becomes too expensive.
Implement **Interest Management** so that clients only receive updates about nearby players.

**Possible approaches:**

- Distance-based visibility
- Area or zone-based replication
- Team or party-based filtering

---

### 3. Networked Data Optimization

Network traffic must be minimized.

- Reduce the number of **Networked properties**
- Avoid frequent **RPC calls**
- Use compressed data structures where possible
- Send movement updates using **prediction and interpolation**

---

### 4. Tick Rate Optimization

The simulation tick rate may need to be adjusted.

- Reduce tick rate (e.g., from 60 to 30)
- Reduce update frequency for non-critical objects

---

### 5. Voice Chat Scaling

Voice chat for 100 users requires grouping.

- Proximity voice chat
- Voice channels or rooms
- Interest Groups
- Optimize traffic: only transmit necessary audio streams, use compression, buffering, etc.

---

## Summary

To support 100 concurrent users the architecture should shift from host-based multiplayer to a dedicated server architecture with:

- Server-authoritative simulation
- Interest management
- Optimized network traffic
- Scalable voice chat