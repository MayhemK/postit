import { Account } from "./Account.js"
import { Album } from "./Album.js"

class Watcher {
  constructor(data) {
    this.id = data.id
    this.accountId = data.accountId
    this.albumId = data.albumId
  }
}

export class WatcherProfile extends Watcher {
  constructor(data) {
    super(data)
    this.profile = new Account(data.profile)
  }
}

export class WatcherAlbum extends Watcher {
  constructor(data) {
    super(data)
    this.album = new Album(data.album)
  }
}