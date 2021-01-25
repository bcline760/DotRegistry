export class GithubOauth {
  public accessToken: string | null;
  public expires_in: number;
  public refresh_token: string | null;
  public refresh_token_expires_in: number;
  public scope: string | null;
  public token_type: string | null;

  constructor() {
    this.accessToken = null;
    this.expires_in = 0;
    this.refresh_token = null;
    this.refresh_token_expires_in = 0;
    this.scope = null;
    this.token_type = null;
  }
}
