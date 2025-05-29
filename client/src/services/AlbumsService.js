import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Album } from "@/models/Album.js"
import { router } from "@/router.js"

class AlbumsService{
  async getAlbumById(albumId) {
    AppState.activeAlbum = null
    const res = await api.get(`api/albums/${albumId}`)
    const album = new Album(res.data)
    AppState.activeAlbum = album
  }
  async createAlbum(albumData) {
    const res = await api.post('api/albums', albumData)
    logger.log('Create Album', res.data)
    const album = new Album(res.data)
    AppState.albums.push(album)
    router.push({ name: 'AlbumDetails', params: { albumId: album.id}})
  }
  async getAlbums() {
    const res = await api.get('api/albums')
    logger.log('Got Albums', res.data)
    const albums = res.data.map(pojo => new Album(pojo))
    AppState.albums = albums
  }

}
export const albumsService = new AlbumsService()