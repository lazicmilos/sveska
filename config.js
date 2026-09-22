// Single source of truth for everything tied to the GitHub account and repo.
// index.html uses the profile link, upload.html also uses the API base.
//
// On GitHub Pages the owner and the repo are already in the URL, so a copy of
// this notebook on another account runs without editing anything here. Fill in
// the overrides only when the URL cannot tell: a custom domain, files opened
// locally, or a notebook served from a subfolder of an <owner>.github.io repo.
const SITE = (function () {
  const OVERRIDE_OWNER = "";
  const OVERRIDE_REPO = "";
  const BRANCH = "main";

  // https://<owner>.github.io/<repo>/ -> owner, repo
  // https://<owner>.github.io/        -> owner, <owner>.github.io
  function fromPagesUrl() {
    const suffix = ".github.io";
    const host = location.hostname.toLowerCase();
    if (!host.endsWith(suffix)) return null;

    const owner = host.slice(0, -suffix.length);
    if (!owner) return null;

    // Drop the file name first, so /index.html on a user site is not read as
    // a repo named "index.html".
    const dir = location.pathname.replace(/[^/]*$/, "");
    const firstSegment = dir.split("/").filter(Boolean)[0];
    return { owner: owner, repo: firstSegment || host };
  }

  const detected = fromPagesUrl() || { owner: "", repo: "" };
  const owner = OVERRIDE_OWNER || detected.owner;
  const repo = OVERRIDE_REPO || detected.repo;

  return Object.freeze({
    owner: owner,
    repo: repo,
    branch: BRANCH,
    // False means neither the URL nor the overrides named a repo, so no write
    // can work. upload.html says that instead of failing on a broken request.
    configured: Boolean(owner && repo),
    profileUrl: "https://github.com/" + owner,
    apiBase: "https://api.github.com/repos/" + owner + "/" + repo
  });
})();
